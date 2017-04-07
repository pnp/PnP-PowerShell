# Introduction
This document described the scripts avaialable as part of this solution.

The scripts included are:
1. CollectSolution
2. ApplySolution
3. CopySolution


## CollectSolution
CollectSolution.ps1 is used to collect all templates as specificed within the config.xml


### Example

./CollectSolution "Dev"  


## ApplySolution

ApplySolution.ps1 is used to apply all templates as specificed within the config.xml

### Example

./ApplySolution -SourceEnvironment "Dev" -DestinationEnvironment "Uat"


## CopySolution

CopySolution.ps1 is used to copy sites from one environment to another environment.

### Example

./CopySolution -SourceEnvironment "Dev" -DestinationEnvironment "Uat"



