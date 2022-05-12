# Maintenance-Updater
Creates and updates item maintenance files for the ChainTrack / CT2020 / HHT application.

This was not developed in a professional context. I hacked this up
out of frustration when having to deal with canned maintenance files.

Feel free to reach out to me or open an issue if you decide to use this,
but have problems getting set up.

## Authentication

Authentication will vary from one organization to another. This is used
to execute the SQL script on the `ct2020` database. However, it is not 
necessary for updating item maintenance files or creating barcodes.

See the `Impersonation` class on authenticating to Windows Active Directory.

## Maintenance Generator

This executes `ISP_Maint.sql` with whatever barcode numbers you provide it,
and creates an item maintenance file with those items based on the target 
system's data. This file can then be processed on other systems to copy 
that item data over.

## Barcodes

Last I checked, this did not work. If I remember correctly, it 
may have something to do with setting the check-digit, but I could be wrong.

## Updating Files

This is a configuration-driven feature. There is a `HOSTDN.2.40.FMT` file 
that the application uses to parse the item maintenance files.

`BATERR.xml` is also used to parse error files.

When the application loads up, there should be a tab for editing files.
Choose a file to load in and it should display a table with all the 
item rows organized by their row Identifiers.
