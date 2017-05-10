using System.Collections.Generic;
using System.Linq;
using PetHome.Models.BindingModels.FoundPets;
using PetHome.Models.ViewModels.FoundPets;
using AutoMapper;
using PetHome.Models.EntityModels;
using System.IO;
using PetHome.Services.Interfaces;
using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public class FoundPetsService : Service, IFoundPetsService
    {
        public FoundPetsService(IPetHomeContext context)
            : base(context)
        {
        }

        public IEnumerable<FoundPetVM> GetFoundPetsVM()
        {
            IEnumerable<FoundPetVM> vm = this.Context.FoundPets.ToList().Select(pet => Mapper.Map<FoundPet, FoundPetVM>(pet)).ToList();

            foreach (var foundPet in vm)
            {
                var user = this.Context.Users.FirstOrDefault(u => u.FoundPets.FirstOrDefault(pet => pet.Id == foundPet.Id) != null);

                if (user != null)
                {
                    string username = user.UserName;
                    foundPet.AssociatedUsername = username;
                }

                foundPet.IsLostPet = false;
            }

            return vm;
        }

        public FoundPetVM GetFoundPetVM(string username, int id)
        {
            FoundPet foundPet = this.Context.FoundPets.FirstOrDefault(p => p.Id == id);

            FoundPetVM vm = Mapper.Map<FoundPet, FoundPetVM>(foundPet);
            vm.IsLostPet = false;
            vm.Comments = vm.Comments.OrderByDescending(comment => comment.DatePosted);
            vm.AssociatedUsername = username;
            return vm;
        }

        public void CreateNewFoundPet(CreateFoundPetBM bind, string username)
        {
            FoundPet foundPet = Mapper.Map<CreateFoundPetBM, FoundPet>(bind);

            ApplicationUser associatedUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            foundPet.AssociatedUser = associatedUser;

            if (bind.Thumbnail != null && bind.Thumbnail.ContentLength > 0)
            {
                var uploadDir = "~/Uploads/FoundPets";
                var imagePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(uploadDir), bind.Thumbnail.FileName);
                var imageUrl = uploadDir + "/" + bind.Thumbnail.FileName;
                bind.Thumbnail.SaveAs(imagePath);
                foundPet.ThumbnailUrl = imageUrl.Remove(0, 1);
            }

            if (associatedUser != null)
            {
                associatedUser.FoundPets.Add(foundPet);
            }
            else
            {
                this.Context.FoundPets.Add(foundPet);
            }

            this.Context.SaveChanges();
        }

        public bool PetBelongsToUser(string username, int id)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null && user.FoundPets.Any(pet => pet.Id == id))
            {
                return true;
            }

            return false;
        }

        public EditFoundPetVM GetEditPetVM(int id)
        {
            FoundPet foundPet = this.Context.FoundPets.FirstOrDefault(p => p.Id == id);

            EditFoundPetVM vm = Mapper.Map<FoundPet, EditFoundPetVM>(foundPet);

            return vm;
        }

        public void DeleteFoundPet(int id)
        {
            FoundPet foundPet = this.Context.FoundPets.Find(id);
            List<Comment> relatedComments = foundPet.Comments;

            foundPet.Comments = null;

            foreach (var comment in this.Context.Comments)
            {
                foreach (var relatedComment in relatedComments)
                {
                    if (comment.Id == relatedComment.Id)
                    {
                        this.Context.Comments.Remove(comment);
                    }
                }
            }


            this.Context.FoundPets.Remove(foundPet);

            this.Context.SaveChanges();
        }

        public void EditPet(EditFoundPetBM bind)
        {
            FoundPet foundPet = this.Context.FoundPets.Find(bind.Id);


            foundPet.AnimalType = bind.AnimalType;
            foundPet.Breed = bind.Breed;
            foundPet.LastSeenLocation = bind.LastSeenLocation;
            foundPet.LastSeenTime = bind.LastSeenTime;
            foundPet.DistinguishingFeatures = bind.DistinguishingFeatures;
            foundPet.Description = bind.Description;
            foundPet.ActionTaken = bind.ActionTaken;

            if (bind.Thumbnail != null && bind.Thumbnail.ContentLength > 0)
            {
                var uploadDir = "~/Uploads/FoundPets";
                var imagePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(uploadDir), bind.Thumbnail.FileName);
                var imageUrl = uploadDir + "/" + bind.Thumbnail.FileName;
                bind.Thumbnail.SaveAs(imagePath);
                foundPet.ThumbnailUrl = imageUrl.Remove(0, 1);

            }

            this.Context.SaveChanges();
        }




    }
}
