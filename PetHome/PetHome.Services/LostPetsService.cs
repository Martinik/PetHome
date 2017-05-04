using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PetHome.Models.EntityModels;
using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.ViewModels.LostPets;
using System.IO;

namespace PetHome.Services
{
    public class LostPetsService : Service
    {
        public IEnumerable<LostPetVM> GetLostPetsVM()
        {
            IEnumerable<LostPetVM> vm = this.Context.LostPets.ToList().Select(pet => Mapper.Map<LostPet, LostPetVM>(pet)).ToList();

            foreach (var lostPet in vm)
            {
                string username = this.Context.Users.FirstOrDefault(u => u.LostPets.FirstOrDefault(pet => pet.Id == lostPet.Id) != null).UserName;

                lostPet.AssociatedUsername = username;
                lostPet.IsLostPet = true;
            }

            return vm;
        }

  
        public LostPetVM GetLostPetVM(string username, int id)
        {
            LostPet lostPet = this.Context.LostPets.FirstOrDefault(p => p.Id == id);

            LostPetVM vm = Mapper.Map<LostPet, LostPetVM>(lostPet);
            vm.IsLostPet = true;
            vm.Comments = vm.Comments.OrderByDescending(comment => comment.DatePosted);
            vm.AssociatedUsername = username;
            return vm;
        }



        public void CreateNewLostPet(CreateLostPetBM bind, string username)
        {
            LostPet lostPet = Mapper.Map<CreateLostPetBM, LostPet>(bind);

            ApplicationUser associatedUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            lostPet.AssociatedUser = associatedUser;

            if (bind.Thumbnail != null && bind.Thumbnail.ContentLength > 0)
            {
                var uploadDir = "~/Uploads/LostPets";
                var imagePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(uploadDir), bind.Thumbnail.FileName);
                var imageUrl = uploadDir + "/" + bind.Thumbnail.FileName;
                bind.Thumbnail.SaveAs(imagePath);
                lostPet.ThumbnailUrl = imageUrl.Remove(0,1);
            }
        
            associatedUser.LostPets.Add(lostPet);
            this.Context.SaveChanges();

        }

        public bool PetBelongsToUser(string username, int id)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user.LostPets.Any(pet => pet.Id == id))
            {
                return true;
            }

            return false;
        }

        public EditLostPetVM GetEditPetVM(int id)
        {
            LostPet lostPet = this.Context.LostPets.FirstOrDefault(p => p.Id == id);

            EditLostPetVM vm = Mapper.Map<LostPet, EditLostPetVM>(lostPet);

            return vm;
        }

        public void DeleteLostPet(int id)
        {
            LostPet lostPet = this.Context.LostPets.Find(id);

            List<Comment> relatedComments = lostPet.Comments;

            lostPet.Comments = null;

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

            this.Context.LostPets.Remove(lostPet);

            this.Context.SaveChanges();
        }

        public void EditPet(EditLostPetBM bind)
        {
            LostPet lostPet = this.Context.LostPets.Find(bind.Id);

            lostPet.Name = bind.Name;
            lostPet.AnimalType = bind.AnimalType;
            lostPet.Breed = bind.Breed;
            lostPet.Age = bind.Age;
            lostPet.LastSeenLocation = bind.LastSeenLocation;
            lostPet.LastSeenTime = bind.LastSeenTime;
            lostPet.DistinguishingFeatures = bind.DistinguishingFeatures;
            lostPet.Temper = bind.Temper;
            lostPet.Description = bind.Description;



            if (bind.Thumbnail != null && bind.Thumbnail.ContentLength > 0)
            {
                var uploadDir = "~/Uploads/LostPets";
                var imagePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(uploadDir), bind.Thumbnail.FileName);
                var imageUrl = uploadDir + "/" + bind.Thumbnail.FileName;
                bind.Thumbnail.SaveAs(imagePath);
                lostPet.ThumbnailUrl = imageUrl.Remove(0, 1);

            }

            this.Context.SaveChanges();
        }
    }
}
