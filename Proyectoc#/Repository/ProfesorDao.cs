using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectoc_.Context;
using Proyectoc_.Models;

namespace Proyectoc_.Repository
{

   

    public class ProfesorDao
    {
        public RegistroAlumunoContext context =
           new RegistroAlumunoContext();


        public Profesor login(string usuario, string pass)
        {
            
            var prof = context.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();
            return prof;
        }
       


}
    }



