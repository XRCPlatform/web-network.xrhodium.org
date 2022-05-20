﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitCoinRhNetwork.Views.Helpers
{
    using System;
    using System.Collections.Generic;
    
    #line 3 "..\..\Views\Helpers\GlobalHelpers.cshtml"
    using System.Collections.Specialized;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using BitCoinRhNetwork;
    
    #line 4 "..\..\Views\Helpers\GlobalHelpers.cshtml"
    using BitCoinRhNetwork.Controllers;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Helpers\GlobalHelpers.cshtml"
    using BitCoinRhNetwork.Library;
    
    #line default
    #line hidden
    using Forloop.HtmlHelpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public class GlobalHelpers : System.Web.WebPages.HelperPage
    {

#line 7 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult ActivePage(string action, string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 8 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    

#line default
#line hidden

#line 9 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, CheckActive(new[] { action }, controller, null));


#line default
#line hidden

#line 9 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                    ;


#line default
#line hidden
});

#line 10 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 12 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult ActivePage(string[] action, string controller)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 13 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    

#line default
#line hidden

#line 14 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, CheckActive(action, controller, null));


#line default
#line hidden

#line 14 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                          ;


#line default
#line hidden
});

#line 15 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 17 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult ActivePage(string action, string controller, NameValueCollection parameters)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 18 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    

#line default
#line hidden

#line 19 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, CheckActive(new[] { action }, controller, parameters));


#line default
#line hidden

#line 19 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                          ;


#line default
#line hidden
});

#line 20 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 22 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult ActivePage(string[] action, string controller, NameValueCollection parameters)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 23 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    

#line default
#line hidden

#line 24 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, CheckActive(action, controller, parameters));


#line default
#line hidden

#line 24 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                ;


#line default
#line hidden
});

#line 25 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 27 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult CheckActive(string[] action, string controller, NameValueCollection parameters)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 28 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    var currentController = View.CurrentPage.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
    var currentAction = View.CurrentPage.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

    if (currentController == controller)
    {    
        if (action.Contains(currentAction))
        {        
            if (parameters != null)
            {
                bool isOk = true;

                foreach (var itemKey in parameters.AllKeys)
                {
                    if (View.Request[itemKey] != parameters[itemKey])
                    {
                        isOk = false;
                    }
                }

                if (isOk)
                {
                    

#line default
#line hidden

#line 50 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, View.Html.Raw("active"));


#line default
#line hidden

#line 50 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                            
                }
            }
            else
            {
                

#line default
#line hidden

#line 55 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, View.Html.Raw("active"));


#line default
#line hidden

#line 55 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                        
            }
        }
    }


#line default
#line hidden
});

#line 59 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 61 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult GenerateTable(List<List<Tuple<string, string, string>>> cells, string classesTable = "", string classesButtons = "", long offset = 0)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 62 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    if (cells != null && cells.Count > 0)
    {
        var header = cells.First();



#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <table");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 1987), Tuple.Create("\"", 2014)
, Tuple.Create(Tuple.Create("", 1995), Tuple.Create("table", 1995), true)

#line 67 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create(" ", 2000), Tuple.Create<System.Object, System.Int32>(classesTable

#line default
#line hidden
, 2001), false)
);

WriteLiteralTo(__razor_helper_writer, ">\r\n            <tr>\r\n");


#line 69 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                

#line default
#line hidden

#line 69 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                 foreach (var value in header)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    <th");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2126), Tuple.Create("\"", 2189)

#line 71 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 2134), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(value.Item3) ? "" : value.Item3

#line default
#line hidden
, 2134), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 71 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                          WriteTo(__razor_helper_writer, value.Item1);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</th>\r\n");


#line 72 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "            </tr>\r\n\r\n");


#line 75 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            

#line default
#line hidden

#line 75 "..\..\Views\Helpers\GlobalHelpers.cshtml"
              
                cells.Remove(header);
                foreach (var item in cells)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    <tr>\r\n");


#line 80 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                        

#line default
#line hidden

#line 80 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                         foreach (var value in item)
                        {
                            if (value.Item2 == null)
                            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                                <td");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2596), Tuple.Create("\"", 2659)

#line 84 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 2604), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(value.Item3) ? "" : value.Item3

#line default
#line hidden
, 2604), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 84 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                                      WriteTo(__razor_helper_writer, value.Item1);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</td>\r\n");


#line 85 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                            }
                            else
                            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                                <td");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2811), Tuple.Create("\"", 2874)

#line 88 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 2819), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(value.Item3) ? "" : value.Item3

#line default
#line hidden
, 2819), false)
);

WriteLiteralTo(__razor_helper_writer, "><a");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 2878), Tuple.Create("\"", 2905)
, Tuple.Create(Tuple.Create("", 2886), Tuple.Create("btn", 2886), true)

#line 88 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                 , Tuple.Create(Tuple.Create(" ", 2889), Tuple.Create<System.Object, System.Int32>(classesButtons

#line default
#line hidden
, 2890), false)
);

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 2906), Tuple.Create("\"", 2925)

#line 88 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 2913), Tuple.Create<System.Object, System.Int32>(value.Item2

#line default
#line hidden
, 2913), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 88 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                                                                                         WriteTo(__razor_helper_writer, View.Html.Raw(value.Item1));


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a></td>                                \r\n");


#line 89 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                            }
                        }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    </tr>\r\n");


#line 92 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                }
            

#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n        </table>\r\n");


#line 95 "..\..\Views\Helpers\GlobalHelpers.cshtml"
    }


#line default
#line hidden
});

#line 96 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 98 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult GeneratePagination(long totalItems, int perPageItems, string action, string classes = "", string classesActive = "", long offset = 0)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 99 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    if (totalItems > perPageItems)
    {
        var pages = totalItems/perPageItems - 1;
        var overfille = totalItems%perPageItems;
        var actualPage = offset/perPageItems;

        if ((overfille > 0) && (overfille <= 5))
        {
            pages++;
        }

        if (action.IsAny() && action.Contains("?"))
        {
            action += "&";
        }
        else
        {
            action += "?";
        }
                


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <ul");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 3776), Tuple.Create("\"", 3803)
, Tuple.Create(Tuple.Create("", 3784), Tuple.Create("pagination", 3784), true)

#line 120 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create(" ", 3794), Tuple.Create<System.Object, System.Int32>(classes

#line default
#line hidden
, 3795), false)
);

WriteLiteralTo(__razor_helper_writer, ">\r\n            \r\n");


#line 122 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            

#line default
#line hidden

#line 122 "..\..\Views\Helpers\GlobalHelpers.cshtml"
             if (actualPage != 0) {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <li");

WriteLiteralTo(__razor_helper_writer, " class=\"first\"");

WriteLiteralTo(__razor_helper_writer, "><a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 3894), Tuple.Create("\"", 3956)

#line 123 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 3901), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 3901), false)
, Tuple.Create(Tuple.Create("", 3910), Tuple.Create("offset=", 3910), true)

#line 123 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 3917), Tuple.Create<System.Object, System.Int32>(perPageItems*actualPage-perPageItems

#line default
#line hidden
, 3917), false)
);

WriteLiteralTo(__razor_helper_writer, ">&laquo;</a></li>\r\n");


#line 124 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            }        


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "            \r\n");


#line 126 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            

#line default
#line hidden

#line 126 "..\..\Views\Helpers\GlobalHelpers.cshtml"
             if (actualPage > 0)
            {
                for (int i = ((int)actualPage - 2); i < ((int)actualPage); i++)
                {
                    if (i >= 0)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <li><a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 4248), Tuple.Create("\"", 4288)

#line 132 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4255), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 4255), false)
, Tuple.Create(Tuple.Create("", 4264), Tuple.Create("offset=", 4264), true)

#line 132 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4271), Tuple.Create<System.Object, System.Int32>(perPageItems*i

#line default
#line hidden
, 4271), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 132 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                           WriteTo(__razor_helper_writer, i + 1);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a></li>\r\n");


#line 133 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                    }
                }
            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "            \r\n            <li");

WriteAttributeTo(__razor_helper_writer, "class", Tuple.Create(" class=\"", 4395), Tuple.Create("\"", 4417)

#line 137 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4403), Tuple.Create<System.Object, System.Int32>(classesActive

#line default
#line hidden
, 4403), false)
);

WriteLiteralTo(__razor_helper_writer, "><a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 4421), Tuple.Create("\"", 4470)

#line 137 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4428), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 4428), false)
, Tuple.Create(Tuple.Create("", 4437), Tuple.Create("offset=", 4437), true)

#line 137 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4444), Tuple.Create<System.Object, System.Int32>(perPageItems*actualPage

#line default
#line hidden
, 4444), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 137 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                               WriteTo(__razor_helper_writer, actualPage + 1);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a></li>\r\n        \r\n");


#line 139 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            

#line default
#line hidden

#line 139 "..\..\Views\Helpers\GlobalHelpers.cshtml"
             if (actualPage < pages)
            {
                for (int i = ((int)actualPage + 1); i < ((int)actualPage + 3); i++)
                {
                    if (i <= pages)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <li><a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 4757), Tuple.Create("\"", 4797)

#line 145 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4764), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 4764), false)
, Tuple.Create(Tuple.Create("", 4773), Tuple.Create("offset=", 4773), true)

#line 145 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4780), Tuple.Create<System.Object, System.Int32>(perPageItems*i

#line default
#line hidden
, 4780), false)
);

WriteLiteralTo(__razor_helper_writer, ">");


#line 145 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                           WriteTo(__razor_helper_writer, i + 1);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</a></li>\r\n");


#line 146 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                    }
                }
                


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <li");

WriteLiteralTo(__razor_helper_writer, " class=\"last\"");

WriteLiteralTo(__razor_helper_writer, "><a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 4913), Tuple.Create("\"", 4975)

#line 149 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4920), Tuple.Create<System.Object, System.Int32>(action

#line default
#line hidden
, 4920), false)
, Tuple.Create(Tuple.Create("", 4929), Tuple.Create("offset=", 4929), true)

#line 149 "..\..\Views\Helpers\GlobalHelpers.cshtml"
, Tuple.Create(Tuple.Create("", 4936), Tuple.Create<System.Object, System.Int32>(perPageItems*actualPage+perPageItems

#line default
#line hidden
, 4936), false)
);

WriteLiteralTo(__razor_helper_writer, ">&raquo;</a></li>\r\n");


#line 150 "..\..\Views\Helpers\GlobalHelpers.cshtml"
            }           


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        </ul>\r\n");


#line 152 "..\..\Views\Helpers\GlobalHelpers.cshtml"
    }


#line default
#line hidden
});

#line 153 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

#line 155 "..\..\Views\Helpers\GlobalHelpers.cshtml"
public static System.Web.WebPages.HelperResult GetShortText(string text, int length)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 156 "..\..\Views\Helpers\GlobalHelpers.cshtml"
 
    if (text.Length > length)
    {
        

#line default
#line hidden

#line 159 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, View.Html.Raw(text.Substring(0, length) + "..."));


#line default
#line hidden

#line 159 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                                                         
    }
    else
    {
        

#line default
#line hidden

#line 163 "..\..\Views\Helpers\GlobalHelpers.cshtml"
WriteTo(__razor_helper_writer, View.Html.Raw(text));


#line default
#line hidden

#line 163 "..\..\Views\Helpers\GlobalHelpers.cshtml"
                            
    }


#line default
#line hidden
});

#line 165 "..\..\Views\Helpers\GlobalHelpers.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
