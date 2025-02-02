﻿using CodePulse.Models.Domain;
using CodePulse.Models.DTO;
using CodePulse.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            //call image respository
            var images = await imageRepository.GetAll();

            //Convert this domain model to DTO
            var response = new List<BlogImageDto>();

            foreach (var image in images)
            {
                response.Add(new BlogImageDto {
                    id = image.id,
                    Title = image.Title,
                    DateCreated = image.DateCreated,
                    FileExtension = image.FileExtension,
                    Filename = image.Filename,
                    Url = image.Url
                });
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidatedFileUpload(file);

            if (ModelState.IsValid)
            {
                //Continue file upload
                var blogImage = new BlogImage
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    Filename = fileName,
                    Title = title,
                    DateCreated = DateTime.Now
                };

                blogImage = await imageRepository.Upload(file, blogImage);

                //Convert Domain Model to DTO
                var response = new BlogImageDto
                {
                    id = blogImage.id,
                    Title = blogImage.Title,
                    DateCreated = blogImage.DateCreated,
                    FileExtension  = blogImage.FileExtension,
                    Filename = blogImage.Filename,
                    Url = blogImage.Url
                };

                return Ok(blogImage);
            }

            return BadRequest(ModelState);

        }

        private void ValidatedFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { "jpg", "jpeg", "png" };

            if (allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower())) 
            {
                ModelState.AddModelError("file", "Unsupported file format.");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB.");
            }
        }

    }
}
