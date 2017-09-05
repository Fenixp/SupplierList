using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupplierList.Business.Interface.Features.Startup.Commands;
using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Features.Suppliers.Models;
using SupplierList.Business.Interface.Features.Suppliers.Queries;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Web.Features.Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierList.Web.Features.Suppliers
{
    public class SuppliersController : Controller
    {
        private ICommandHandler<AddSupplierCommand> _addSupplierCommandHandler;
        private ICommandHandler<EditSupplierCommand> _editSupplierCommandHandler;
        private ICommandHandler<DeleteSupplierCommand> _deleteSupplierCommandHandler;
        private IQueryHandler<IEnumerable<GroupModel>, GroupsQuery> _groupsQueryHandler;
        private IQueryHandler<SupplierDetailModel, SupplierDetailQuery> _supplierDetailQueryHandler;
        private IQueryHandler<IEnumerable<SupplierModel>, SuppliersQuery> _suppliersQueryHandler;

        public SuppliersController(
                ICommandHandler<AddSupplierCommand> addSupplierCommandHandler,
                ICommandHandler<EditSupplierCommand> editSupplierCommandHandler,
                ICommandHandler<DeleteSupplierCommand> deleteSupplierCommandHandler,
                IQueryHandler<IEnumerable<GroupModel>, GroupsQuery> groupsQueryHandler,
                IQueryHandler<SupplierDetailModel, SupplierDetailQuery> supplierDetailQueryHandler,
                IQueryHandler<IEnumerable<SupplierModel>, SuppliersQuery> suppliersQueryHandler
            )
        {
            _addSupplierCommandHandler = addSupplierCommandHandler;
            _editSupplierCommandHandler = editSupplierCommandHandler;
            _deleteSupplierCommandHandler = deleteSupplierCommandHandler;
            _groupsQueryHandler = groupsQueryHandler;
            _supplierDetailQueryHandler = supplierDetailQueryHandler;
            _suppliersQueryHandler = suppliersQueryHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexModel model = new IndexModel
            {
                Suppliers = _suppliersQueryHandler.Handle(new SuppliersQuery()),
                Groups = GetGroupsWithNullValue(_groupsQueryHandler.Handle(new GroupsQuery()))
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexModel form)
        {
            IndexModel model = new IndexModel
            {
                Suppliers = _suppliersQueryHandler.Handle(new SuppliersQuery { GroupId = form.SelectedGroupId }),
                SelectedGroupId = form.SelectedGroupId,
                Groups = GetGroupsWithNullValue(_groupsQueryHandler.Handle(new GroupsQuery()))
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            EditSupplierModel model = new EditSupplierModel
            {
                Groups = _groupsQueryHandler.Handle(new GroupsQuery())
                    .Select(x => new SelectListItem
                    {
                        Value = x.GroupId.ToString(),
                        Text = x.Name
                    })
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddSupplier(EditSupplierModel model)
        {
            _addSupplierCommandHandler.Handle(new AddSupplierCommand
            {
                Address = model.Address,
                Email = model.Email,
                GroupIds = model.SelectedGroups,
                Name = model.Name,
                Phone = model.Phone
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSupplier(int supplierId)
        {
            SupplierDetailModel supplierDetail = _supplierDetailQueryHandler.Handle(new SupplierDetailQuery { SupplierId = supplierId });

            EditSupplierModel model = new EditSupplierModel
            {
                Address = supplierDetail.Address,
                Email = supplierDetail.Email,
                Name = supplierDetail.Name,
                Phone = supplierDetail.Phone,
                SelectedGroups = supplierDetail.Groups?.Select(x => x.GroupId),
                Groups = _groupsQueryHandler.Handle(new GroupsQuery())
                    .Select(x => new SelectListItem
                    {
                        Value = x.GroupId.ToString(),
                        Text = x.Name
                    })
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditSupplier(EditSupplierModel model)
        {
            _editSupplierCommandHandler.Handle(new EditSupplierCommand
            {
                Address = model.Address,
                Email = model.Email,
                GroupIds = model.SelectedGroups,
                Name = model.Name,
                Phone = model.Phone,
                SupplierId = model.SupplierId
            });

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSupplier(int supplierId)
        {
            _deleteSupplierCommandHandler.Handle(new DeleteSupplierCommand { SupplierId = supplierId });

            return RedirectToAction("Index");
        }

        // Error handler pro produkci
        public IActionResult Error()
        {
            return View();
        }

        private IEnumerable<SelectListItem> GetGroupsWithNullValue(IEnumerable<GroupModel> groups)
        {
            List<SelectListItem> groupsList = _groupsQueryHandler.Handle(new GroupsQuery())
                    .Select(x => new SelectListItem
                    {
                        Value = x.GroupId.ToString(),
                        Text = x.Name
                    }).ToList();

            return groupsList.Prepend(new SelectListItem
            {
                Value = null,
                Text = "-"
            });
        }
    }
}
