import {MainPicHeader, SocialMedia, TextPartHeader} from "../../../index.ts";
import style from "./homeHeader.module.scss"

const HomeHeader = () => {
    return (
        <header className={style.wrapper}>
            <TextPartHeader/>
            <MainPicHeader/>
            <SocialMedia/>
        </header>
    );
}
export default  HomeHeader;