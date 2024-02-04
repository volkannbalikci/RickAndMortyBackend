using RickAndMorty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Enumarations;

public class Gender : Enumeration
{
    public static Gender Female = new(1, nameof(Female));
    public static Gender Male = new(2, nameof(Male));
    public static Gender Genderless = new(3, nameof(Genderless));
    public static Gender Unknown = new(4, nameof(Unknown));
    public Gender(int id, string name) : base(id, name)
    {
    }
}
