using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BuyList.Domain.Commands.ItemCommands
{
    public class CreateItemCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string TypeOfMeasure { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
        public string OwnerId { get; set; }

        public CreateItemCommand() { }

        public CreateItemCommand(string name, int quantity, string typeOfMeasure, decimal value, string category, string ownerId)
        {
            Name = name;
            Quantity = quantity;
            TypeOfMeasure = typeOfMeasure;
            Value = value;
            Category = category;
            OwnerId = ownerId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Nome", "Por favor insira um nome com pelo menos 2 caracteres!")
                .HasMaxLen(Name, 40, "Nome", "O nome não pode conter mais de 40 caracteres!")
                .IsNotNull(Quantity, "Quantidade", "A quantidade não pode ser nula!")
                .IsNotNull(TypeOfMeasure, "Tipo de medida", "O tipo de medida não pode ser vazio!")
                .IsNotNull(Value, "Valor", "O valor não pode ser nulo!")
                .HasMinLen(Category, 2, "Categoria", "Por favor insira a categoria com pelo menos 2 caracteres!")
                .HasMaxLen(Category, 40, "Categoria", "A categoria não pode conter mais de 40 caracteres!")
                .IsNotNull(Category, "Categoria", "A categoria não pode ser nula!")
                .IsNotNull(OwnerId, "Usuário", "O usuário não pode ser nulo!")
            );
        }
    }
}