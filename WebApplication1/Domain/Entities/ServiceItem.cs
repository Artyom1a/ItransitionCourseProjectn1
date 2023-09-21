using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Domain.Entities
{
    public class ServiceItem : EntityBase
    {

        [Display(Name = "Название обзора")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание обзора")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание обзора")]
        public override string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }


    }
}









