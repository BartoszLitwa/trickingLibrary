using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace SubmissioningLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/submissions")]
    public class SubmissionCotroller : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public SubmissionCotroller(AppDbContext ctx)
        {
            this._ctx = ctx;
        }

        // /api/Submissions
        [HttpGet]
        public IEnumerable<Submission> All() => _ctx.Submissions.ToList();

        // /api/Submissions/{id}
        [HttpGet("{id}")]
        public async Task<Submission> GetAsync(int id) => await _ctx.Submissions.FirstOrDefaultAsync(x => x.Id.Equals(id));

        // /api/Submissions/{SubmissionId}/submissions
        [HttpGet("{SubmissionId}/submissions")]
        public IEnumerable<Submission> ListSubmissionsForSubmission(int SubmissionId) =>
            _ctx.Submissions.Where(x => x.Id.Equals(SubmissionId)).ToList();

        // /api/Submissions
        [HttpPost]
        public async Task<Submission> CreateAsync([FromBody] Submission Submission) {
            await _ctx.Submissions.AddAsync(Submission);

            await _ctx.SaveChangesAsync();
            return Submission;
        }

        // /api/Submissions
        [HttpPut]
        public async Task<Submission> UpdateAsync([FromBody] Submission submission)
        {
            if(submission.Id == 0) return null;

            var t = _ctx.Submissions.FirstOrDefault(x => x.Id.Equals(submission.Id));
            t.Deleted = true;

            await _ctx.SaveChangesAsync();
            return submission;
        }

        // /api/Submissions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var submission = _ctx.Submissions.FirstOrDefault(x => x.Id.Equals(id));
            if (submission == null) return NotFound();

            submission.Deleted = true;
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
