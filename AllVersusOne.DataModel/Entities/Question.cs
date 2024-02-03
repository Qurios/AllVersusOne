using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllVersusOne.DataModel;

namespace AllVersusOne.DataModel.Entities;

public class Question : IEntity
{
    public int Id { get; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public int UpperLimit { get; set; }

    public int LowerLimit { get; set; }

    public int CorrectAnswer { get; set; }
}
