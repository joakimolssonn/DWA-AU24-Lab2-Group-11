using Microsoft.AspNetCore.Mvc.RazorPages;
using DWA_AU24_Lab2_Group_11.Models;
using System.Collections.Generic;

namespace DWA_AU24_Lab2_Group_11.Views.Admin
{
    public class IndexModel : PageModel
    {
        public List<User> Users { get; set; }
    }
}
