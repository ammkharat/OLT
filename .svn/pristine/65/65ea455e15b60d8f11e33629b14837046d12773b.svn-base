

/* This script populates the PlantId for existing users based on what site they are associated with. */
/* Denver users do not get their PlantId set yet as we are waiting to hear about what plant they should be set to. */

/* set all Site Wide Services users to the one Site Wide Services plant */
update [user]
set PlantId = 1000
where 6 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* set all MacKay River users to the one MacKay River plant */
update [user]
set PlantId = 754
where 7 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* set all Firebag users to the one Firebag plant */
update [user]
set PlantId = 1400
where 5 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* all Oilsands users at the present time are in extraction, so we know to set the PlantId to 1200 (extraction) */
update [user]
set PlantId = 1200
where 3 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* set all Sarnia users to the one Sarnia plant */
update [user]
set PlantId = 4000
where 1 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* set all Denver users to plant 7000 because Kath said to */
update [user]
set PlantId = 7000
where 2 in (select SiteId from UserSiteRole where UserId = [user].Id);

/* make all people with multiple sites have no plant id */
update [user]
set PlantId = null
where (select count(*) from UserSiteRole where UserId = [user].Id) > 1;




GO
