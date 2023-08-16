import style from "./leftFooter.module.scss"
import {FooterLinks} from "../../../index.ts";
import {Link} from "react-router-dom";

export const LeftFooter = () => {
    return (
        <div className={style.wrapper}>
            <h1><Link to="/" > SushiRest </Link></h1>
            <FooterLinks/>
        </div>
    );
}
