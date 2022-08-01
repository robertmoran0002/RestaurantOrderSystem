
import { PlaceOrder } from "./Orders/PlaceOrder";
import { Order } from "./Orders/Order";
import { Menus } from "./Menus";
import { Home } from "./Home";
import { Countries } from "./Countries";
import { Categories } from "./Categories";
import { Locations } from "./Locations";
import { Regions } from "./Regions";

const AppRoutes = [
    {
        index: true,
        path: '/',
        element: <Home />
  },

    {
        path: '/orders',
        element: <Order />
    },

    {
        path: '/placeOrder',
        element: <PlaceOrder />
    },
    {
        path: '/locations',
        element: <Locations />
    },
    {
        path: '/categories',
        element: <Categories />
    },
    {
        path: '/menu',
        element: <Menus />
    },
    {
        path: '/countries',
        element: <Countries />
    },
    {
        path: '/regions',
        element: <Regions />
    }
  
];

export default AppRoutes;
