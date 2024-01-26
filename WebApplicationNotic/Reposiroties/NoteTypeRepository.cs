using WebApplicationNotic.Db.DbConnector;
using WebApplicationNotic.Db.Models;

namespace WebApplicationNotic.Reposiroties;

public class NoteTypeRepository
{
    private NoticDbContext _dbContext;

    public NoteTypeRepository(NoticDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<NoteType> GetNoteTypes()
    {
        return _dbContext.NoteTypes.ToList();
    }
}