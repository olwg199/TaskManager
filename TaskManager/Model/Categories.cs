using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public enum Categories
    {
        [Display(Name = "Разное")]
        Others,

        [Display(Name = "Работа по дому")]
        HomeWork
    }
}
