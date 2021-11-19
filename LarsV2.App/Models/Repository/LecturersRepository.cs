﻿using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LarsV2.Models.Repository
{
    public class LecturersRepository : ILecturersRepository
    {
        private readonly LecturerDbContext _context;

        public LecturersRepository(LecturerDbContext context)
        {
            _context = context;
        }
        public PagedList<Lecturer> GetLecturers(LecturerResourceParameters parameters)
        {
            if(parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var collection = _context.Lecturers as IQueryable<Lecturer>;

            if(!string.IsNullOrWhiteSpace(parameters.Subject))
            {
                var subject = parameters.Subject.Trim();
                //collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Name == subject));
            }

            if(!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();
                collection = collection.Where(l=> l.FirstName.Contains(searchQuery) || l.LastName.Contains(searchQuery) || l.Email.Contains(searchQuery) || l.PhoneNumber.Contains(searchQuery));
            }

            return PagedList<Lecturer>.Create(collection, parameters.PageNumber, parameters.PageSize);
        }

        public Lecturer GetLecturer(int id)
        {
            return _context.Lecturers.FirstOrDefault(e => e.Id == id);
        }

        public LecturerWithSubjectsDto GetLecturerWithSubjects(int id)
        {
            var lecturerWithSubjects = _context.Lecturers.Where(l => l.Id == id).Select(l => new LecturerWithSubjectsDto()
            {
                Name = l.FirstName + " " + l.LastName,
                Email = l.Email,
                PhoneNumber = l.PhoneNumber,
                Subjects = l.LecturerSubjects.Select(x => x.Subject).ToList()
            }).FirstOrDefault();

            return lecturerWithSubjects;
        }

        public bool LecturerExists(int id)
        {
            return _context.Lecturers.Any(l => l.Id == id);
        }

        public void AddLecturer(Lecturer lecturer)
        {
            if(lecturer == null)
            {
                throw new ArgumentNullException(nameof(lecturer));
            }

            _context.Lecturers.Add(lecturer);
        }

        public void DeleteLecturer(Lecturer lecturer)
        {
            if(lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
            }   
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            // No implementation needed
        }
    }
}