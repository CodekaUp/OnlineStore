namespace ProductsService.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ИД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Артикул
        /// </summary>
        public int Article {  get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
