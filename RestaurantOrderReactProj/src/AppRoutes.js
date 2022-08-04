
import { PlaceOrder } from "./Orders/PlaceOrder";
import { Order } from "./Orders/Order";
import { AddToOrder } from "./Orders/AddToOrder";
import { Menus } from "./Menus";
import { Home } from "./Home";
import { Countries } from "./Countries";
import { Categories } from "./Categories";
import { Locations } from "./Locations";
import { Regions } from "./Regions";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/home',
        element: <Home />

    },

    {
        path: '/orders',
        element: <Order />
    },
    {
        path: '/addToOrders',
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
