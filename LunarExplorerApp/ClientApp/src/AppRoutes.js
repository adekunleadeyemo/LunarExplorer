import { Home } from "./components/Home";
import { PlateauWithRouter } from "./components/Plateau";
import { MoonExplorer } from "./components/MoonExplorer";
import { RoverWithRouter } from "./components/Rover"
import { Result } from "./components/Result"

const AppRoutes = [
    {
    index: true,
    element: <Home />
    },
    {
    path: '/rover',
    element: <RoverWithRouter />
    },
    {
    path: '/plateau',
    element: <PlateauWithRouter />
    },
    {
    path: '/moonexplorer',
    element: <MoonExplorer />
    },
    {
        path: '/result',
        element: <Result />
    }
];

export default AppRoutes;
