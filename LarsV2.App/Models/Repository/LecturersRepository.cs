﻿using LarsV2.Helpers;
using LarsV2.Models.DBContext;
using LarsV2.Models.DTO;
using LarsV2.Models.Entities;
using LarsV2.Models.ResourceParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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

            if (!string.IsNullOrWhiteSpace(parameters.Education) && !string.IsNullOrWhiteSpace(parameters.Subject))
            {
                var education = parameters.Education.Trim();
                var subject = parameters.Subject.Trim();
                collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Education == education && e.Subject.Title == subject));
            }
            else
            {             
                if (!string.IsNullOrWhiteSpace(parameters.Education))
                {
                    var education = parameters.Education.Trim();
                    collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Education == education));
                }

                if(!string.IsNullOrWhiteSpace(parameters.Subject))
                {
                    var subject = parameters.Subject.Trim();
                    collection = collection.Where(l => l.LecturerSubjects.Any(e => e.Subject.Title == subject));
                }
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();
                searchQuery = Regex.Replace(searchQuery, @"\s+", " ");

                collection = collection.Where(l => string.Concat(l.FirstName + " ", l.LastName).Contains(searchQuery) || l.Email.Contains(searchQuery) || l.PhoneNumber.Contains(searchQuery));
            }

            collection = collection.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            return PagedList<Lecturer>.Create(collection, parameters.PageNumber, parameters.PageSize);
        }

        public Lecturer GetLecturer(int id)
        {
            var lecturer = _context.Lecturers
                .Where(e => e.Id == id)
                .Include(e => e.LecturerSubjects)
                .ThenInclude(e => e.Subject)
                .FirstOrDefault();

            return lecturer;
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