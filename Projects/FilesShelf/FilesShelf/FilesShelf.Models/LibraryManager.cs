using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilesShelf.Models
{
    public abstract class LibraryManager 
    {
        public IRenderer IRenderer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public virtual void Serialize(ISerializable obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual Object Unserialize()
        {
            throw new System.NotImplementedException();
        }

        public virtual MediaLibrary CreateLibrary()
        {
            throw new System.NotImplementedException();
        }

        public virtual void DeleteLibrary()
        {
            throw new System.NotImplementedException();
        }
    }
}
