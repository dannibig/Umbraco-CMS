﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.WebApi.Filters;

namespace Umbraco.Web.Trees
{
    [CoreTree(TreeGroup = Constants.Trees.Groups.Settings)]
    [UmbracoTreeAuthorize(Constants.Trees.MemberTypes)]
    [Tree(Constants.Applications.Settings, Constants.Trees.MemberTypes, null, sortOrder: 2)]
    public class MemberTypeTreeController : MemberTypeAndGroupTreeControllerBase
    {
        protected override TreeNode CreateRootNode(FormDataCollection queryStrings)
        {
            var root = base.CreateRootNode(queryStrings);
            //check if there are any member types
            root.HasChildren = Services.MemberTypeService.GetAll().Any();
            return root;
        }
        protected override IEnumerable<TreeNode> GetTreeNodesFromService(string id, FormDataCollection queryStrings)
        {
            return Services.MemberTypeService.GetAll()
                .OrderBy(x => x.Name)
                .Select(dt => CreateTreeNode(dt, Constants.ObjectTypes.MemberType, id, queryStrings, "icon-item-arrangement", false));
        }
    }
}
