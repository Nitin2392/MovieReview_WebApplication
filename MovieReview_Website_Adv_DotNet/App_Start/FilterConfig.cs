﻿using System.Web;
using System.Web.Mvc;

namespace MovieReview_Website_Adv_DotNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}