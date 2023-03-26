import style from "./DownHeader.module.css"
import TextPartHeader from "./TextPartHeader/TextPartHeader";
import MainPicHeader from "./MainPicHeader/MainPicHeader";
import SocialMedia from "./SocialMedia/SocialMedia";

const DownHeader = () => {
    return (
        <div className={style.wrapper}>
            <TextPartHeader/>
            <MainPicHeader/>
            <SocialMedia/>
        </div>
    );
}
export  default DownHeader;