namespace Twitter.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTweetBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Text { get; set; }
    }
}