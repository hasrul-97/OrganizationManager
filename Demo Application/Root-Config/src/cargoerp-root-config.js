import { registerApplication, start } from "single-spa";
import {
  constructApplications,
  constructRoutes,
  constructLayoutEngine,
} from "single-spa-layout";

const routes = constructRoutes(document.querySelector("#single-spa-layout"));
const applications = constructApplications({
  routes,
  loadApp({ name }) {
    return System.import(name);
  },
});

//  REGISTERING ANN APPLICATION BASED ON SPECIFIC URL
registerApplication({
  name: "@cargoerp/shipment",
  app: () => System.import("@cargoerp/shipment"),
  activeWhen: "/shipment",
  customProps: {
    token: 'This is CARGO ERP'
  },
});

//  REGISTERING ANN APPLICATION BASED ON SPECIFIC URL
registerApplication({
  name: "@cargoerp/organization",
  app: () => System.import("@cargoerp/organization"),
  activeWhen: "/organization",
  customProps: {
    token: 'This is CARGO ERP'
  },
});

//  REGISTERING ANN APPLICATION BASED ON SPECIFIC URL
registerApplication({
  name: "@cargoerp/dashboard",
  app: () => System.import("@cargoerp/dashboard"),
  activeWhen: "/dashboard",
  customProps: {
    token: 'This is CARGO ERP'
  },
});

const layoutEngine = constructLayoutEngine({ routes, applications });

applications.forEach(registerApplication);
layoutEngine.activate();
start();