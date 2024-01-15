using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWeb.Models;

namespace RazorWeb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly RazorWeb.Models.MyBlogContext _context;

        public IndexModel(RazorWeb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public const int ITEMS_PER_PAGES = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentpage { get; set; }
        public int countpage { get; set; }

        public async Task OnGetAsync(string SearchString)
        {

            var totalPage = await _context.articles.CountAsync();
            countpage = (int)Math.Ceiling((double)totalPage / ITEMS_PER_PAGES);

            if(currentpage < 1 )
                currentpage = 1;
            if(currentpage > countpage)
                currentpage = countpage;

            /*Article = await _context.articles.ToListAsync(); */
            var articles = (from p in _context.articles
                           orderby p.Created descending
                           select p)
                           .Skip((currentpage - 1) * 10)
                           .Take(ITEMS_PER_PAGES);
            if(!string.IsNullOrEmpty(SearchString))
            {
                Article = articles.Where(q => q.Title.Contains(SearchString)).ToList();
            } else
            {

                Article = await articles.ToListAsync();
            }
        }
    }
}
