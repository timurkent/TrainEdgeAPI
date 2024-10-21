using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainEdgeAPI.Data;
using TrainEdgeAPI.Models;

namespace TrainEdgeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Details(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) {
                return NotFound();
            }
            return student;
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<Student>> FindByUserId(string userId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.UserId == userId);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            /*if (ModelState.IsValid)
            {*/
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Details), new { id = student.Id }, student);
            /*}
            return View(student);*/
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Student student)
        {
            var foundStudent = await _context.Students.FindAsync(student.Id);
            if (foundStudent == null) {
                foundStudent = await _context.Students.FirstOrDefaultAsync(x => x.UserId == student.UserId);
                if(foundStudent == null) { 
                    return NotFound(); 
                }
            }

            foundStudent.Birthdate = student.Birthdate;
            foundStudent.Email = student.Email;
            foundStudent.UserId = student.UserId;
            foundStudent.Username = student.Username;
            foundStudent.Password = student.Password;
            foundStudent.Telegram = student.Telegram;
            foundStudent.IsAdmin = student.IsAdmin;
            await _context.SaveChangesAsync();
            return Ok(foundStudent);
        }

        // GET: Students/Delete/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Ok");
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
