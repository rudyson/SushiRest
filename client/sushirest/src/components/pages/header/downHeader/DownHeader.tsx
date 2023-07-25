import style from "./DownHeader.module.scss"
import {TextPartHeader, SocialMedia, MainPicHeader} from "../../../../index.ts";

export const DownHeader = () => {
    return (
        <div className={style.wrapper}>
            <TextPartHeader/>
            <MainPicHeader/>
            <SocialMedia/>
        </div>
    );
}
