import {Delivery, AboutUs, TopPositions, Feedbacks} from "../../index.ts"
import HomeHeader from "./homeHeader/homeHeader.tsx";

const Home = () => {
    return (
        <>
            <HomeHeader/>
            <TopPositions/>
            <Feedbacks/>
            <Delivery/>
            <AboutUs/>
        </>
    );
}

export default Home;