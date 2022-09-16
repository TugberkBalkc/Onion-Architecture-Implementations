using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Constansts
{
    public static class BusinessConstants
    {
        //General Messages
        public const String NotFound = "Not Found";

        public const String AlreadyExists = "Already Exists";


        //Entity Constant Names
        public const String Entry = "Entry";
        public const String EntryFavorite = "Entry Favorite";
        public const String EntryVote = "Entry Vote";

        public const String EntryComment = "Entry Comment";
        public const String EntryCommentFavorite = "Entry Comment Favorite";
        public const String EntryCommentVote = "Entry Comment Vote";

        public const String User = "User";

        public const String Role = "Role";

        public const String EmailConfirmation = "Email Confirmation";

        public const String OperationClaim = "Operation Claim";

        public const String RoleOperationClaim = "Operation Claims In This Role";

    }
}
