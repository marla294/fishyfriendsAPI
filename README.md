# Fish Friends API

## About

Author: Marla Foreman

This will eventually be a web application that will allow you to check whether a group of saltwater fish are compatible or not, for the purposes of starting a saltwater aquarium.  For now, it is an in-progress API.

The data used for fish compatibility can be found on this website: https://www.ocellarisclownfish.com/compatibility/.

## Tech Used

* .NET framework
* NUnit
* PostgreSQL
* ReactJS (for the site, coming soon)

## API Help

### Fish

GET api/Fish - returns all fish in the database

### Compatibility

GET api/Compatibility?fishNames={name1}&fishNames={name2} - returns compatibility number for all fish passed to fishNames.  May pass as many fish as you want.
