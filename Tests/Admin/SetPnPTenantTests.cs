using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Admin
{

    [TestClass]
    public class SetTenantTests
    {
        #region Test Setup/CleanUp

        [TestInitialize]
        public void Initialize()
        {
            using (var scope = new PSTestScope())
            {
                // Example
                // scope.ExecuteCommand("cmdlet", new CommandParameter("param1", prop));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var scope = new PSTestScope())
            {
                try
                {

                }
                catch (Exception)
                {
                    // Describe Exception
                }
            }
        }

        #endregion

        #region Scaffolded Cmdlet Tests

        

        //TODO: This is a scaffold of the cmdlet - complete the unit test
        //[TestMethod]
        public void SetPnPTenantTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPTenant",new CommandParameter("SpecialCharactersStateInFileFolderNames", "null"),new CommandParameter("MinCompatibilityLevel", "null"),new CommandParameter("MaxCompatibilityLevel", "null"),new CommandParameter("ExternalServicesEnabled", "null"),new CommandParameter("NoAccessRedirectUrl", "null"),new CommandParameter("SharingCapability", "null"),new CommandParameter("DisplayStartASiteOption", "null"),new CommandParameter("StartASiteFormUrl", "null"),new CommandParameter("ShowEveryoneClaim", "null"),new CommandParameter("ShowAllUsersClaim", "null"),new CommandParameter("ShowEveryoneExceptExternalUsersClaim", "null"),new CommandParameter("SearchResolveExactEmailOrUPN", "null"),new CommandParameter("OfficeClientADALDisabled", "null"),new CommandParameter("LegacyAuthProtocolsEnabled", "null"),new CommandParameter("RequireAcceptingAccountMatchInvitedAccount", "null"),new CommandParameter("ProvisionSharedWithEveryoneFolder", "null"),new CommandParameter("SignInAccelerationDomain", "null"),new CommandParameter("EnableGuestSignInAcceleration", "null"),new CommandParameter("UsePersistentCookiesForExplorerView", "null"),new CommandParameter("BccExternalSharingInvitations", "null"),new CommandParameter("BccExternalSharingInvitationsList", "null"),new CommandParameter("UserVoiceForFeedbackEnabled", "null"),new CommandParameter("PublicCdnEnabled", "null"),new CommandParameter("PublicCdnAllowedFileTypes", "null"),new CommandParameter("RequireAnonymousLinksExpireInDays", "null"),new CommandParameter("SharingAllowedDomainList", "null"),new CommandParameter("SharingBlockedDomainList", "null"),new CommandParameter("SharingDomainRestrictionMode", "null"),new CommandParameter("OneDriveStorageQuota", "null"),new CommandParameter("OneDriveForGuestsEnabled", "null"),new CommandParameter("IPAddressEnforcement", "null"),new CommandParameter("IPAddressAllowList", "null"),new CommandParameter("IPAddressWACTokenLifetime", "null"),new CommandParameter("UseFindPeopleInPeoplePicker", "null"),new CommandParameter("DefaultSharingLinkType", "null"),new CommandParameter("ODBMembersCanShare", "null"),new CommandParameter("ODBAccessRequests", "null"),new CommandParameter("PreventExternalUsersFromResharing", "null"),new CommandParameter("ShowPeoplePickerSuggestionsForGuestUsers", "null"),new CommandParameter("FileAnonymousLinkType", "null"),new CommandParameter("FolderAnonymousLinkType", "null"),new CommandParameter("NotifyOwnersWhenItemsReshared", "null"),new CommandParameter("NotifyOwnersWhenInvitationsAccepted", "null"),new CommandParameter("NotificationsInOneDriveForBusinessEnabled", "null"),new CommandParameter("NotificationsInSharePointEnabled", "null"),new CommandParameter("OwnerAnonymousNotification", "null"),new CommandParameter("CommentsOnSitePagesDisabled", "null"),new CommandParameter("SocialBarOnSitePagesDisabled", "null"),new CommandParameter("OrphanedPersonalSitesRetentionPeriod", "null"),new CommandParameter("DisallowInfectedFileDownload", "null"),new CommandParameter("DefaultLinkPermission", "null"),new CommandParameter("ConditionalAccessPolicy", "null"),new CommandParameter("AllowDownloadingNonWebViewableFiles", "null"),new CommandParameter("AllowEditing", "null"),new CommandParameter("ApplyAppEnforcedRestrictionsToAdHocRecipients", "null"),new CommandParameter("FilePickerExternalImageSearchEnabled", "null"),new CommandParameter("EmailAttestationRequired", "null"),new CommandParameter("EmailAttestationReAuthDays", "null"),new CommandParameter("HideDefaultThemes", "null"),new CommandParameter("DisabledWebPartIds", "null"),new CommandParameter("EnableAIPIntegration", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            