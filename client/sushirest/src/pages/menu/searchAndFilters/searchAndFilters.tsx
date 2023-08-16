import style from "./searchAndFilters.module.scss"
import {FilterPopUp, Search, SortPopUp} from "../../../index.ts";
import {useDispatch, useSelector} from "react-redux";
import {setCategoryId, setSearchValue, setSortId} from "../../../store/slices/filter/filterSlice.ts";
export const SearchAndFilters= () => {
    const dispatch = useDispatch()

    const {categoryId, sortId} = useSelector(state => state.filter)
    const onChangeCategory = (id) => {
        dispatch(setCategoryId(id))
    }

    const onChangeSort = (id) => {
        dispatch(setSortId(id))
    }

    const setSearch = (str) => {
        dispatch(setSearchValue(str))
    }
    return (
        <section className={style.wrapper}>
            <Search setSearch={setSearch}/>
            <FilterPopUp categoryId = {categoryId} onChangeCategory = {onChangeCategory} />
            <SortPopUp sortId = {sortId} onChangeSort = {onChangeSort} />
        </section>
    )
}
