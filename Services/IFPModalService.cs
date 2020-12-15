using Microsoft.AspNetCore.Mvc.Rendering;
using moni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Services
{
    public interface IFPModalService
    {
        public SelectList CategoryDropDown(FPUser user);
        public SelectList CategoryItemDropDown(Category category);
    }
}
