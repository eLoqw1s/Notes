using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Contracts.Notes
{
    public record NoteDetailsVm
    (
        Guid Id,
        string Title,
        string Details,
        DateTime CreationDate,
        DateTime? EditDate
    );
}
