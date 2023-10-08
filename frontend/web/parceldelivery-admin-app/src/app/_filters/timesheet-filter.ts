/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { SqlBaseFilter } from "./sql-base-filter";
import { Timesheet } from "../_models/timesheet";

export class TimesheetFilter extends SqlBaseFilter<Timesheet> {
    userId: string | undefined;
    minDateFrom: Date | undefined;
    maxDateFrom: Date | undefined;
    minDateTo: Date | undefined;
    maxDateTo: Date | undefined;
    day: string | undefined;
    note: string | undefined;
}
