﻿using System.Web;
using System.Web.Mvc;

namespace ToDoList.Applications.ApplicationWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
