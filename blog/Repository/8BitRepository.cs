using blog.Entities;
using blog.Entities._8bit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace blog.Repository
{
    public class _8BitRepository(BlogContext context)
    {
        public IQueryable<Sequencer> GetSequencer()
        {
            return context.Sequencers.Include(x => x.Tracks).ThenInclude(x => x.Step).Include(x => x.UpdateUser).Include(x => x.CreateUser).AsQueryable();
        }

        public IQueryable<Sequencer> GetSequencerNoInclude()
        {
            return context.Sequencers.AsQueryable();
        }
    }
}
