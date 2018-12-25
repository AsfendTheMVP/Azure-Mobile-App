using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using NotesBackend.DataObjects;
using NotesBackend.Models;

namespace NotesBackend.Controllers
{
    public class NotesController : TableController<Notes>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Notes>(context, Request);
        }

        // GET tables/Notes
        public IQueryable<Notes> GetAllNotes()
        {
            return Query(); 
        }

        // GET tables/Notes/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Notes> GetNotes(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Notes/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Notes> PatchNotes(string id, Delta<Notes> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Notes
        public async Task<IHttpActionResult> PostNotes(Notes item)
        {
            Notes current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Notes/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotes(string id)
        {
             return DeleteAsync(id);
        }
    }
}
