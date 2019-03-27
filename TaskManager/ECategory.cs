using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum ECategory
    {
        [Display(Name = "Разное")]
        Others,

        [Display(Name = "Работа по дому")]
        HomeWork
    }
}
