
HOW RUN ASPNET CORE ANGULAR SPA APP:

For latest Ng version:
Delete delete ClientApp

Create new ClientApp:
ng new ClientApp

npm install --save-dev @angular-devkit/build-angular

Inside ClientApp directory:
ng s -o

Go back Aspnet Core project root:
dotnet run

Go to localhost indicated on the commandline


===========================================================================================

ANGULAR 7 NOTES:


ERROR in Could not resolve module /C/GeeCentral/Dev/C
i ?wdm?: Failed to compile.

Error: 
fixed 0 of 1 vulnerability in 40178 scanned packages
  1 vulnerability required manual review and could not be updated

Run:
npm audit fix

If not fixed, run:
npm audit
CHECKOUT PACKAGES AND DIPENDENCIES

-------------------------------------------------------------------
  High            Missing Origin Validation
  Package         webpack-dev-server
  Patched in      >=3.1.11
  Dependency of   @angular-devkit/build-angular [dev]
  Path            @angular-devkit/build-angular > webpack-dev-server
  More info       https://nodesecurity.io/advisories/725
-------------------------------------------------------------------

Down-graded @angular-devkit/build-angular to:
"@angular-devkit/build-angular": "~0.7.0" or
"@angular-devkit/build-angular": "~0.11.4"
===========================================================================================
