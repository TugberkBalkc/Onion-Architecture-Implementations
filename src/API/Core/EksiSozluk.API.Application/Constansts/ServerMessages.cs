using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Constansts
{
    public static class ServerMessages
    {


        //User Messages
        public const String UserLoggedIn = "User Logged In";
        public const String EmailOrPasswordIsWrong = "Wrong Email Or Password";
        public const String UserRegistered = "User Registered";
        public const String PasswordChanged = "Password Changed";
        public const String WrongOldPassword = "Old Password Is Wrong";
        public const String UserDeleted = "User Deleted";
        public const String UserUpdated = "User Updated";
        public const String EmailNowConfirmed = "Email Is Now Confirmed";
        public const String UserNotFoundWithEmail = "User Not Found With This Email";
        public const String UserEmailAlreadyConfirmed = "Email Address Already Confirmed";
        public const String UsersRoleUpdated = "Users Role Updated";


        //Role Messages
        public const String RoleCreated = "Role Created";
        public const String RoleDeleted = "Role Deleted";
        public const String RoleUpdate = "Role Updated";
        public const String ClaimAddedInRole = "Authority Added To Role";
        public const String ClaimRemovedInRole = "Authority Has Taken Back In Role";


        //Claim Messages
        public const String ClaimCreated = "Operation Claim Created";
        public const String ClaimDeleted = "Operation Claim Deleted";
        public const String ClaimUpdated = "Operation Claim Updated";
        public const String ClaimsRecieved = "Operation Claims Recieved";


        //Entry Messages
        public const String EntryCreated = "Entry Created";
        public const String EntryDeleted = "Entry Deleted";
        public const String EntryUpdated = "Entry Updated";
        public const String EntryRecieved = "Entry Recieved";
        public const String EntriesRecieved = "Entries Recieved";


        //Entry Favorite Messages 
        public const String EntryAddedToFavorites = "Entry Added In Favorites";
        public const String EntryRemovedInFavorites = "Entry Removed In Favorites";


        //Entry Vote Messages 
        public const String EntryVoteCreated = "Entry Voted";
        public const String EntryVoteDeleted = "Entry Vote Deleted";
        public const String EntryVoteUpdated = "Entry Vote Updated";



        // Entry Comment Messages
        public const String EntryCommentCreated = "Comment Created";
        public const String EntryCommentDeleted = "Comment Deleted";
        public const String EntryCommentUpdated = "Comment Updated";
        public const String EntryCommentRecieved = "Comment Recieved";


        // Entry Comment Favorite Messages
        public const String EntryCommentFavoriteCreated = "Comment Added In Favorites";
        public const String EntryCommentFavoriteDeleted = "Comment Deleted In Favorites";


        // Entry Comment Vote Messages
        public const String EntryCommentVoteCreated = "Comment Voted";
        public const String EntryCommentVoteDeleted = "Comment Vote Deleted";
        public const String EntryCommentVoteUpdated = "Comment Vote Updated";

        //General Messages
        public const String ValidationFailed = "Validation Failed";

        public const String SomethingWentWrong = "Something Went Wrong";

        public const String NotFound = "Not Found";

        public const String AlreadyExists = "Already Exists";
    }
}
