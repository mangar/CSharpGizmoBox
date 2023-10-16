namespace CSGizmoBox.Entity.Validation
{
    public abstract class BaseValidate<T>
    {

        public List<ValidationVO> ValidateMessages { get; set; } = new List<ValidationVO>();


        public BaseValidate<T> AddMessage(ValidationVO ValidationVO)
        {
            if (ValidationVO != null && !ValidationVO.IsValid)
            {
                ValidateMessages.Add(ValidationVO);
            }
            return this;

        }


        public bool IsValid()
        {
            return ValidateMessages.Count() == 0 ? true : false;
        }


        public abstract bool Validate();


    }
}
