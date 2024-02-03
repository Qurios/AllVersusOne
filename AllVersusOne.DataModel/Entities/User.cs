using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllVersusOne.DataModel.Enums;

namespace AllVersusOne.DataModel.Entities;

public class User : IEntity
{
    public int Id { get; }

    public string Name { get; set; }

    public string Group { get; set; }

    public UserType Type { get; set; }
}