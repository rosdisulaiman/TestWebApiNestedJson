using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDataShaper<T>
    {
        //IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
        //ExpandoObject ShapeData(T entity, string fieldsString);

        //IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString);
        //Entity ShapeData(T entity, string fieldsString);

        IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);
        ShapedEntity ShapeData(T entity, string fieldsString);
    }
}
