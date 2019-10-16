using RestSharpDataDriven.DataTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestSharpDataDriven.Common
{
    class MockPet
    {
        private Pet pet;
        public Category NewCategoryObject()
        {
            var category = new Category();
            category.ctgId = 0;
            category.ctgName = "string";

            return category; 
        }

        public ICollection<Tag> NewTagObject()
        {
            var tag = new Tag();
            tag.tagId = 0;
            tag.tagName = "string";

            var tagList = new Collection<Tag>();
            tagList.Add(tag);

            return tagList;
        }

        public ICollection<string> NewphotoUrls()
        {
            var newphotoUrls = new Collection<string>();
            newphotoUrls.Add("string");
            return newphotoUrls;
        }

        public MockPet(Pet pet)
        {
            this.pet = pet;
            this.pet.petId = 121991;
            this.pet.category = NewCategoryObject();
            this.pet.petName = "blackCat";
            this.pet.photoUrls = NewphotoUrls();
            this.pet.tag = NewTagObject();
            this.pet.petStatus = Pet.PetStatus.available;
        }
    }
}
