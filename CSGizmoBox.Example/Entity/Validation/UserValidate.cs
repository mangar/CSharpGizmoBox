using CSGizmoBox.Entity.Validation;
using CSGizmoBox.Entity.Validation.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGizmoBox.Example.Entity.Validation
{
    public class UserValidate : BaseValidate<User>
    {

        public UserValidate(User user) => this.user = user;

        public User user { get; set; }

        public override bool Validate()
        {

            return AddMessage(StringNotEmptyValidation.Validate(user.Nome, Message:"Campo NOME não pode ficar em branco"))
                .AddMessage(EmailValidation.Validate(user.Email))
                .AddMessage(StringNotEmptyValidation.Validate(user.Senha, Message:"Campo SENHA deve ser preenchido"))
                .IsValid();
        }
    }
}
