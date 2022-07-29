import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },

    {
        path: '/orders',
        requireAuth: true,
        element: <Order />
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
        requireAuth: true,
        element: <Regions />
    },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
