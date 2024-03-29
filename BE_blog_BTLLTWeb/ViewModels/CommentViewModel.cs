﻿using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.ViewModels
{
	public class CommentViewModel
	{
		BlogBtlContext db = new BlogBtlContext();
		public CommentViewModel(CommentBlog comment,string currentUser)
		{
			idComment = comment.IdComment;
			avatar = db.Accounts.Find(comment.IdAccount).Avatar;
			username = db.Accounts.Find(comment.IdAccount).UserName;
			fullname = db.Accounts.Find(comment.IdAccount).Fullname;
			idBlog = comment.IdBlog.Value.ToString();
			content = comment.Content;
			createAt = comment.CreateAt.Value.ToString("MMM dd, yyyy");
			
			if (currentUser == username)
			{
				isYourComment= "(You)";
			}
			else
			{
				isYourComment= "";
			}
		}

		private string avatar;
		private string username;
		private string fullname;
		private string content;
		private string createAt;
		private string idBlog;
		private int idComment;
		private string isYourComment;
		public string Avatar { get => avatar; set => avatar = value; }
		public string Username { get => username; set => username = value; }
		public string Content { get => content; set => content = value; }
		public string CreateAt { get => createAt; set => createAt = value; }
		public string Fullname { get => fullname; set => fullname = value; }
		public string IsYourComment { get => isYourComment; set => isYourComment = value; }
		public string IdBlog { get => idBlog; set => idBlog = value; }
		public int IdComment { get => idComment; set => idComment = value; }
	}
}
