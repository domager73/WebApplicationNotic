using WebApplicationNotic.Dto;
using WebApplicationNotic.Reposiroties;

namespace WebApplicationNotic.Services;

public class NoteTypeService
{
    private NoteTypeRepository _noteTypeRepository;

    public NoteTypeService(NoteTypeRepository noteTypeRepository)
    {
        _noteTypeRepository = noteTypeRepository;
    }

    public List<ResponseNoteTypeDto> GetNoteType()
    {
        
    }
}